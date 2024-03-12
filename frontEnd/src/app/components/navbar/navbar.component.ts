import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  @Output() selectComponent = new EventEmitter<string>();

  constructor() { }

  onSelect(component: string): void {
    this.selectComponent.emit(component);
  }
}