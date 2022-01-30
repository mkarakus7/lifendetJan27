import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { BreadcrumbService} from 'xng-breadcrumb';
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;

  constructor(private shopServ: ShopService,
    private activRoute: ActivatedRoute,
    private bcService: BreadcrumbService
    ) { 

      this.bcService.set('@productDetails',' ');
    }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.shopServ.getProduct
    (+this.activRoute.snapshot.paramMap.get('id'))
    .subscribe( product =>{
      this.product = product;
      this.bcService.set('@productDetails', product.name);
    }, error =>{
      console.log(error);
    });
  }

}
