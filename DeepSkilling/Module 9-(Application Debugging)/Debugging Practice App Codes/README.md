# Module 9 – Angular Application Debugging: Hands-On Practice Kit

This kit gives you a small Angular app with **5 intentionally planted bugs**.
Your job is to find and fix each one using the exact tool called out in the
Module 9 learning objectives. Nothing here is theoretical — every exercise
produces a visible, wrong result in the browser that you must trace back
to its cause.

---

## 0. One-time setup

You need Node.js + Angular CLI installed locally (this can't be run inside
this chat sandbox — no network access here).

```bash
npm install -g @angular/cli
ng new debug-practice-app --routing=false --style=css
cd debug-practice-app
ng add @ngrx/store@latest
```

Then copy the files from this kit into the new project, overwriting the
matching paths:

- `src/app/app.component.ts` → replace generated one
- `src/app/counter.service.ts` → new file
- `src/app/buggy-list.component.ts` → new file
- `src/app/store/*` → new files
- `.vscode/launch.json` → drop into project root's `.vscode/`

Run it:

```bash
ng serve
```

Open `http://localhost:4200`.

---

## 1. Debugging with Chrome DevTools

**Reference:** javascript.info/debugging-chrome, GeeksforGeeks DevTools articles

### Exercise A — Inspect the DOM tree
1. Press `F12` to open DevTools → **Elements** panel.
2. Find the `<app-buggy-list>` element. Notice the list renders duplicate
   `<li>` items with the same text after you click "Add Item" a few times.
3. Use the DOM tree to confirm the duplicate nodes exist (this is a
   `trackBy` bug in `buggy-list.component.ts` — you'll fix it in Exercise D).

### Exercise B — Sources panel, breakpoints, call stack
1. Go to **Sources** panel → find your file under
   `webpack://` → `src/app/counter.service.ts` (TypeScript, thanks to
   source maps).
2. Set a breakpoint inside `increment()`.
3. Click the "+1" button in the UI. Execution pauses at your breakpoint.
4. Inspect the **Call Stack** pane — trace the click handler back through
   `AppComponent.onIncrement()` → `CounterService.increment()`.
5. Use **Step Over (F10)** to step through the buggy line
   `this.count += 2;` and watch the **Scope** panel to see `count` jump
   by 2 instead of 1. This is the bug — fix it once you've confirmed it live.

### Exercise C — Watch expressions
1. While paused at the breakpoint above, add a **Watch expression**:
   `this.count`.
2. Step through and observe the value changing in real time in the Watch pane.

---

## 2. Debugging Angular-specific code (TypeScript + source maps)

1. Confirm source maps are enabled — check `angular.json`,
   `"sourceMap": true` under the `build` options (default in a new project).
2. In DevTools Sources panel, verify you're stepping through **`.ts` files**,
   not compiled JS. If you only see `main.js`, source maps aren't wired up —
   troubleshoot `angular.json` before continuing.

---

## 3. Debugging Angular in VS Code

**Reference:** the Medium/plainenglish articles on VS Code Angular debugging

### Exercise D — Attach the VS Code debugger
1. Install the **Debugger for Chrome** (built into modern VS Code) — no
   extra extension needed in recent VS Code versions.
2. Also install **Angular Language Service** extension for `.ts`/template
   IntelliSense while you debug.
3. Use the provided `.vscode/launch.json` (already in this kit). It has two
   configs:
   - `ng serve` — runs the dev server as a VS Code task
   - `Launch Chrome against localhost` — opens Chrome attached to VS Code's
     debugger
4. Press `F5` in VS Code. Chrome opens; VS Code is now the debugger.

### Exercise E — Breakpoints & watches directly in VS Code
1. Open `src/app/buggy-list.component.ts` inside VS Code.
2. Set a breakpoint on the line inside `addItem()` where the array is
   mutated.
3. Trigger "Add Item" in the browser — VS Code should pause execution.
4. In the **Variables** pane, expand `this.items` and confirm whether
   Angular's change detection actually saw a new array reference (it
   won't — that's the bug: `this.items.push(...)` mutates in place instead
   of `this.items = [...this.items, newItem]`).
5. Add a **Watch**: `this.items.length` and step to see it update even
   though the view sometimes doesn't (until you fix `trackBy`/immutability).
6. Fix both bugs, save, and confirm no more duplicate `<li>` nodes.

---

## 4. Debugging state management (NgRx store)

**Files:** `src/app/store/counter.actions.ts`,
`counter.reducer.ts`, `counter.selectors.ts`

### Exercise F — Redux DevTools + breakpoints in the reducer
1. Install the **Redux DevTools** Chrome extension.
2. Open it alongside your app — you'll see dispatched actions
   (`[Counter] Increment`, etc.) and the state tree.
3. Click "Increment via Store" in the UI. Notice in Redux DevTools that
   the action fires, but the displayed count from the store doesn't change.
4. Set a breakpoint inside `counterReducer` in VS Code (or Sources panel).
5. Step through the `switch` statement — you'll find the bug: the case
   string `'[Counter] Increment'` doesn't match the actual action type
   because of a typo (`'[Counter] Incrment'`). Fix the typo in
   `counter.actions.ts` or the reducer so they match, and re-test.
6. Use the Redux DevTools **time-travel** slider to confirm state changes
   correctly after your fix.

---

## 5. Wrap-up checklist (map back to learning objectives)

- [ ] Used Chrome DevTools Elements panel to inspect DOM tree
- [ ] Set a breakpoint in Sources panel and read the call stack
- [ ] Used a Watch expression in Chrome DevTools
- [ ] Verified TypeScript source maps are working (stepped through `.ts`, not `.js`)
- [ ] Configured and used VS Code's `launch.json` to attach to Chrome
- [ ] Set a breakpoint and watch inside VS Code
- [ ] Inspected a service's internal state during a running app
- [ ] Used Redux DevTools to inspect and time-travel NgRx state
- [ ] Fixed all 5 planted bugs and confirmed the app behaves correctly

Once every box is checked, you have concrete, reproducible evidence of
having practiced every sub-topic in Module 9 — not just read the linked
articles.
