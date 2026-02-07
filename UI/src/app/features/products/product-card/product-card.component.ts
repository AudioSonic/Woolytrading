import { Component, Input } from '@angular/core';
import { Product } from '../../../model/product.model'; // Pfad ggf. anpassen

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
})
export class ProductCardComponent {
  @Input({ required: true }) product!: Product;
}
