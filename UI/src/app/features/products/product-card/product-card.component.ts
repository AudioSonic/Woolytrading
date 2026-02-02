import { Component, Input } from '@angular/core';

export interface Product {
  name: string;
  price: number;
}

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
})
export class ProductCardComponent {
  @Input({ required: true }) product!: Product;
}
