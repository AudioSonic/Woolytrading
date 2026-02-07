import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
})

export class ProductDetailComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id'); // 'id' must match the route path: 'products/:id'
      console.log('Product ID from URL:', id);
      // Note: 'id' will be a string. Convert if you need a number: const numericId = +id;
    });
  }
}
  
