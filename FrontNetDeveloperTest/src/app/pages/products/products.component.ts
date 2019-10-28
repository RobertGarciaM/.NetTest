import { Component, OnInit } from '@angular/core';
import { ProductsServices } from './services/products.service';
import { Products } from './interfaces/IProducts';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public products: Products[];
  constructor(private productsServices: ProductsServices) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts(){
    this.productsServices.GetProducts().subscribe(response => {
      if ( response.status === 200) {
       this.products = response.data;
      }
    });
  }

  reserveProduct(item: Products){
    this.productsServices.RserverProducts(item).subscribe(response => {
      this.loadProducts();
    });
  }
}
