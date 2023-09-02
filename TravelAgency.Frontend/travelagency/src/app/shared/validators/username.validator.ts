import { inject } from "@angular/core";
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from "@angular/forms";
import { ApiService } from "../services/api.service";

export function usernameAvailabilityValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Promise<ValidationErrors | null> => {
        const value = control.value;
        const api = inject(ApiService);
        return new Promise<ValidationErrors | null>((resolve, reject) => {
            if(!value)
                resolve(null);
            api.usernameCheck(value).subscribe({
                next: (response) => {
                if(response[0].IsTaken)
                    resolve({usernameTaken: true});
                else
                    resolve(null);
            }, error: (error) => {
                reject(error);
            }});
        });
    }
}