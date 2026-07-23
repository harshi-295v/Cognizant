import { Component } from '@angular/core';

@Component({
  selector: 'app-buggy-list',
  standalone: true,
  template: `
    <h3>Buggy List (find the DOM + change-detection bugs)</h3>
    <button (click)="addItem()">Add Item</button>
    <ul>
      <!-- BUG: no trackBy, and items are mutated in place below,
           so Angular sometimes fails to re-render correctly and
           you'll see duplicate/stale <li> nodes in the Elements panel. -->
      <li *ngFor="let item of items">{{ item.label }} (#{{ item.id }})</li>
    </ul>
  `,
})
export class BuggyListComponent {
  items: { id: number; label: string }[] = [];
  private nextId = 1;

  addItem(): void {
    // BUG: mutating the array in place instead of creating a new
    // reference. Set a VS Code breakpoint here, inspect `this.items`
    // in the Variables pane, then fix with:
    // this.items = [...this.items, { id: this.nextId, label: 'Item' }];
    this.items.push({ id: this.nextId, label: 'Item' });
    this.nextId++;
  }
}
