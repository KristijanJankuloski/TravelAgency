import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'messageType'
})
export class MessageTypePipe implements PipeTransform {

  transform(value: number): string {
    switch(value){
      case 0:
        return "Испраќање договор";
      case 1:
        return "Испраќање фактура";
      case 2:
        return "Потсетник за плаќање";
      case 3:
        return "Потсетник за патување";
      default:
        return "Друго";
    }
  }

}
