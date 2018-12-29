import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent1 } from './app.component';
import { productListComponent } from './products/product-list.component';

import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent1,
    productListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  bootstrap: [AppComponent1]
})
export class AppModule { }
