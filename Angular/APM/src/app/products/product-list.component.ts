import { Component, OnInit } from "@angular/core";
import { IProduct } from "./product";
import { ProductService } from "./product.service";

@Component({
    selector: 'pm-products',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css'],
    providers: [ProductService]
})
export class productListComponent implements OnInit {
    performFilter(filterBy: string): IProduct[] {
        filterBy = filterBy.toLocaleLowerCase();

        //Similar to LINQ and lambda expressions in C#
        return this.products.filter((product: IProduct) =>
        product.productName.toLocaleLowerCase().indexOf(filterBy)!=-1);
    }
    constructor(private productService: ProductService){
       
        //this.listFilter = 'cart';
    }
    ngOnInit(): void {
        console.log('in onInit');
        this.products = this.productService.getProducts();
        this.filteredProducts = this.products;
    }
    
    filteredProducts: IProduct[];

    pageTitle: string = "### Product List ###";
    products: IProduct[] = [];
    showImage: boolean = false;
    imageWidth = 50;
    imageMargin = 2;
    _listFilter: string;

    get listFilter(): string {
        return this._listFilter;
      }
      set listFilter(value: string) {
        this._listFilter = value;
        this.filteredProducts = this.listFilter ? this.performFilter(this.listFilter) : this.products;
      }

    toggleImage(): void{
        this.showImage = !this.showImage;
    }
}