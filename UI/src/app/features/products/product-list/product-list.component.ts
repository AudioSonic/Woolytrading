import { Component } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  // This is the property you are adding
  public products: any[] = [
    {
      id: 1,
      name: 'Wooly Jumper',
      description: 'A warm and cozy jumper made from the finest digital wool.',
      price: 49.99
    },
    {
      id: 2,
      name: 'Code Scarf',
      description: 'A stylish scarf that keeps you warm during long debugging sessions.',
      price: 24.99
    },
    {
      id: 3,
      name: 'Syntax Socks',
      description: 'Comfortable socks guaranteed to reduce syntax errors by 10%.',
      price: 9.99
    }
  ];
  trackByProductId(index: number, product: any): number {
    return product.id;
  }
  constructor() { }

}
