# CSS

### Include css in html
```html
<head>
  ...
  <link rel="stylesheet" href="styles.css?v=1.0">
    ...
</head>
```

### Syntax 
Basic syntax `selector { property: value }`

The selector is the (X)HTML element that you want to style. The property is the actual property title, and the value is the style you apply to that property.

```css
body {
  background: #eeeeee;
  font-family: “Trebuchet MS”, Verdana, Arial, serif;
}
```

### Comments
```css
/* This is a comment */
```

### Combining selectors
You can combine elements within one selector in the following fashion.

```css
h1, h2, h3, h4, h5, h6 {
  color: #009900;
  font-family: Georgia, sans-serif;
}
```

### Classes
The class selector allows you to style items within the same (X)HTML element differently.
Basic syntax `.class { property: value }`

Example
```html
<div>The <span class="italic">very long</span>text used here only for example.</div>
```

```css
.italic {
    font-style: italic;
}
```

### CSS IDs

IDs are similar to classes, except once a specific id has been declared it cannot be used again within the same (X)HTML file.
Basic syntax `#id { property: value }`

Example
```html
<div id=”container”>
Everything within my document is inside this division.
</div>
```
```css
#container{
  background: #ffffff;
}
```

### Divisions
Divisions are a block level (X)HTML element used to define sections of an (X)HTML file. A division can contain all the parts that make up your website. Including additional divisions, spans, images, text and so on.  A division creates a linebreak by default
```html
<div>
Site contents go here
</div>
```
### Spans
Spans are very similar to divisions except they are an inline element versus a block level element. No linebreak is created when a span is declared. For example see `Classes` section.

### [Pseudo class](https://www.w3schools.com/css/css_pseudo_classes.asp)
A pseudo-class is used to define a special state of an element.
For example, it can be used to:
- Style an element when a user mouses over it
- Style visited and unvisited links differently
- Style an element when it gets focus

```css
selector:pseudo-class {
  property: value;
}
```
```css
a:visited {
  color: #00FF00;
}
```

### Overflow
You can control what an elements contents will do if it overflows it boundaries with the overflow property

`overflow: value;`

Values:
- auto
- hidden
- visible
- scroll

Overflow Example
As you can see, with this property you can mimic an iframe. This box is set to an overflow value of “auto”. Meaning that if the contents of the element break the boundaries it should add a scrollbar.

- If it we’re set to an overflow value of “scroll”, horizontal and vertical scrollbars would appear no matter what.
- If it we’re set to an overflow value of “hidden”, the contents would be clipped at the boundary and no scrollbar would appear.
- If it we’re set to an overflow value of “visible”, the contents would expand past the boundaries and no scrollbar would appear.

### Z-Index
You can control the layer order of positioned elements with the z-index property

`z-index: value;`

Values:
-auto
-number

The higher the number the higher the level. Negative numbers are allowed