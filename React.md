### React rules and good practices
- Components should be small
- One component in one file
- HTML returned from component must have one root element

### Create react app 
```bash
npx create-react-app <app name>
```

### Sample component
```js
export default function SampleComponent() {
    return (
        <div>
        ... rest of code here ...
        <div/>
    );
}
```

### Using one component into another one
```js
export default function ComponentA() {
    return (
        <div>Component A content!<div/>
    );
}

```

```js
import ComponentA from './ComponentA';

export default function ComponentB() {
    return (
        <ComponentA/>
    );
}
```

### Add css for component (Just simply import CSS file (WTF!!!))
```css
.sample-item {
    ...
}
```

```js
import './SampleComponent.css';

export default function SampleComponent() {
    return (
        <div className="sample-item">
        ... rest of code here ...
        <div/>
    );
}
```

### Use values from code (use curly braces in template)
```js
export default function SampleComponent() {
    const date = new Date();

    return (
        <div>
            <p>Current date: {date.toDateString()}<p/>
        <div/>
    );
}
```

### Sharing data between components
Two methods of consume data
```js
export default function DateComponent(props) {
  return <h1>{props.dateToDisplay.toDateString()}</h1>;
}
```
```js
export default function DateComponent({dateToDisplay}) {
  return <h1>{dateToDisplay.toDateString()}</h1>;
}
```


```js
export function App(props) {
  const date = new Date();
  
  return (
    <div>
      <DateComponent dateToDisplay={date} />
    </div>
  );
}
```

