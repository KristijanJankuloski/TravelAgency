import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'paymentMethodCast'
})
export class PaymentMethodCastPipe implements PipeTransform {

  transform(value: number): string {
    switch (value){
      case 0:
        return "Кеш";
      case 1:
        return "Картичка";
      case 2:
        return "Фактура";
      default:
        return "Друго";
    }
  }

}
