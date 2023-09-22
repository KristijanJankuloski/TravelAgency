import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './services/auth.service';

export const anonymousGuard: CanActivateFn = (route, state) => {
  const router: Router = inject(Router);
  const auth = inject(AuthService);

  if(!auth.isLoggedIn){
    return true;
  }
  router.navigate(['home']);
  return false;
};
