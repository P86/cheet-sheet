![logo](https://cdn.worldvectorlogo.com/logos/angular-3.svg )

### Access to model property in template
```html
<h2>{{item.property}}</h2>
```

### For loop in template 
```html
<ul>
  <li *ngFor="let item of items">
    <span>{{item.property}}</span>
  </li>
</ul>
```

### Bind function to event in template 
```html
<button (click)="onClick()">Click</button>
```
```ts
 onClick(): void {
    ....
  }
```

### Bind model to input in template
```html
<textarea [(ngModel)]="item.property" placeholder="Some input..." ></textarea>
```

### Set style of selected element
```html
[class.selected]="quiz === selectedQuiz"
```

### Check if model is not null
```html
<div *ngIf="item">
```

### Inseet module in template
```html
<div>
  <child-module></child-module>
</div>
```

### Link that navigates to route
```html
<a [routerLink]='["/api/resource"]'>Go somwhere</a>
```