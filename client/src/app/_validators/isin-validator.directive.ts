import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator } from '@angular/forms';

@Directive({
  selector: '[appIsinValidator]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: ISINValidatorDirective,
    multi: true
  }]
})
export class ISINValidatorDirective implements Validator {
  validate(control: AbstractControl) : {[key: string]: any} | null {
    // if (control.value && control.value.length != 2) {
      return { 'IsinInvalid': false };
    // }
    return null;
  }
}
