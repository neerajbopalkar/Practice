import { Component, OnInit } from "@angular/core";
import { IProduct } from "./product";

@Component({
    selector: 'pm-products',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class productListComponent implements OnInit {
    performFilter(filterBy: string): IProduct[] {
        filterBy = filterBy.toLocaleLowerCase();

        //Similar to LINQ and lambda expressions in C#
        return this.products.filter((product: IProduct) =>
        product.productName.toLocaleLowerCase().indexOf(filterBy)!=-1);
    }
    constructor(){
        this.filteredProducts = this.products;
        this.listFilter = 'cart';
    }
    ngOnInit(): void {
        console.log('in onInit');
    }
    
    filteredProducts: IProduct[];

    pageTitle: string = "### Product List ###";
    products: IProduct[] = [
        {
            "productId": 1,
            "productName": "Leaf Rake",
            "productCode": "GDN-0011",
            "releaseDate": "March 19, 2016",
            "description": "Leaf rake with 48-inch wooden handle.",
            "price": 19.95,
            "starRating": 3.2,            
            "imageUrl": "https://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
        },
        {
            "productId": 2,
            "productName": "Garden Cart",
            "productCode": "GDN-0023",
            "releaseDate": "March 18, 2016",
            "description": "15 gallon capacity rolling garden cart",
            "price": 32.99,
            "starRating": 4.2,
            "imageUrl": "https://openclipart.org/image/300px/svg_to_png/58471/garden_cart.png"
        }
    ];
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