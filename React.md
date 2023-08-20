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

### Dynamically style componnent
Just use code inside curly braces and change style of component.
```jsx
const [isValid, setIsValid] = useState(true);
...
<div className="some-class">
    <p style={{ color: isValid ? 'red' : 'black' }}>Some Text</p>
</div>
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
```ts
export type Props = {
   dateToDisplay: Date;
}

export default function DateComponent({ dateToDisplay }: Props) {
  return <h1>{dateToDisplay.toDateString()}</h1>;
}[]()
```
```ts
export default function DateComponent({ dateToDisplay: Date }) {
  return <h1>{dateToDisplay.toDateString()}</h1>;f
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

## Hooks

### useEffect()

Helps to deal with code that should be executed in response of some action. UseEffect executes function **after** every compontent evaluation **if** the specified dependencies changed

```js
useEffect(() => {...}, [dependencies]);
```


### useReducer()

Helps to deal with complex state when `useState()` is not sufficient. Can be used as a replacement for `useState()`

### useContext()

Can be used in situation when there is need to pass state or handlers to many components down in hierarchy or use data from component that is not up in hierarchy. Basically context can be used to manage application wide context. It is similar to create reactive facade in angular, that expose methods to mutate state and observables that allows observe state change. 

```jsx
const SomeContext = createContext(defaultValue);

export default SomeContext;
```

This create component like class that should be used in jsx code to wrap all components that should have access to context.

```jsx
import SomeContext from 'some-context.js'

<App>
	<SomeContext.Provider>
		<ComponentA />
		<ComponentB />
	</SomeContext.Provider>
</App>
```

To consume context vale use `useContext` hook.

```jsx
import { useContext } from 'react';
import SomeContext from 'some-context.js';
...
const ctx = useContext(SomeContext);
```

Functions also can be part of context, they can be used in a same way as a props.

To create context that relays on some state context provider can be wrapped in component. This is recommended approach.

```jsx
import { useState } from 'react';
import SomeContext from 'some-context.js'

export const SomeContextProvider = (props) => {
	const [state, setState] = useState({});
	const someHandler = () => {};
	return <SomeContext.Provider value={{state, someHandler}}>{props.children}</AuthContext.Provider>
}
```

> [!INFO]
> Context is not optimized for high frequency changes. In that case use different state tool like `Redux`
