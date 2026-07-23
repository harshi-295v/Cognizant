import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CounterService {
  count = 0;

  // BUG (find via Chrome DevTools breakpoint + Watch expression):
  // this increments by 2 instead of 1. Set a breakpoint here,
  // step through, and watch `this.count` change by the wrong amount.
  increment(): void {
    this.count += 2; // <-- should be += 1
  }

  decrement(): void {
    this.count -= 1;
  }

  reset(): void {
    this.count = 0;
  }
}
