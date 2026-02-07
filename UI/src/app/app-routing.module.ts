import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/layout/home/home.component';
import { ProductsComponent } from './core/layout/products/products.component';
import { NotFoundComponent } from './core/layout/not-found/not-found.component';
import { ProductListComponent } from './features/products/product-list/product-list.component';
import { ProductDetailComponent } from './features/products/product-detail/product-detail.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'product-list', component: ProductListComponent },
  { path: 'products/:id', component: ProductDetailComponent },
  { path: 'productDetail', component: ProductDetailComponent }, 
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Redirect to home
  { path: '**', component: NotFoundComponent } // Optional: Wildcard for 404 pages
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
