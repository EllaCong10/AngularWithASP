import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; // 如果你要登录后跳转页面

@Component({
  selector: 'app-login',
  standalone: false,// 这里需要特别配置，否则cannot be declared in an NgModule
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = '';
  password = '';
  loginFailed = false;

  constructor(private http: HttpClient, private router: Router) { }

  onSubmit() {
    const loginData = { email: this.email, password: this.password };

    this.http.post('/api/auth/login', loginData).subscribe({
      next: (res: any) => {
        this.loginFailed = false;
        alert('登录成功！');
        // 跳转到天气页面
        this.router.navigate(['/fetch-data']);
      },
      error: (err) => {
        this.loginFailed = true;
        alert(err?.error?.message || '登录失败');
      },
    });
  }
}
