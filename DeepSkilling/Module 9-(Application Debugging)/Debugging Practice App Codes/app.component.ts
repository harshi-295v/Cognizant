import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { CounterService } from './counter.service';
import { BuggyListComponent } from './buggy-list.component';
import { increment as incrementAction } from './store/counter.actions';
import { selectCount } from './store/counter.selectors';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, BuggyListComponent],
  template: `
    <h2>Module 9 – Debugging Practice App</h2>

    <section>
      <h3>Local service counter</h3>
      <p>Count: {{ counterService.count }}</p>
      <button (click)="onIncrement()">+1</button>
      <button (click)="counterService.decrement()">-1</button>
      <button (click)="counterService.reset()">Reset</button>
    </section>

    <section>
      <h3>NgRx store counter</h3>
      <p>Store count: {{ storeCount$ | async }}</p>
      <button (click)="onIncrementViaStore()">Increment via Store</button>
    </section>

    <app-buggy-list></app-buggy-list>
  `,
})
export class AppComponent {
  storeCount$: Observable<number>;

  constructor(
    public counterService: CounterService,
    private store: Store
  ) {
    this.storeCount$ = this.store.select(selectCount);
  }

  onIncrement(): void {
    this.counterService.increment();
  }

  onIncrementViaStore(): void {
    this.store.dispatch(incrementAction());
  }
}
