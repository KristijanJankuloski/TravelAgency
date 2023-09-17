import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function passwordRepeatValidator() : ValidatorFn {
    return (control: AbstractControl) : ValidationErrors | null => {
        const password = control.get("password");
        const passwordRepeated = control.get("passwordRepeated");
        if(password && passwordRepeated && password.value !== passwordRepeated.value){
            return { passwordMismatch: true };
        }
        return null;
    }
}