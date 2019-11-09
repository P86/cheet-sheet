### Variable bindings
Simple declaration
```rust
let x = 32;
```
Type also can be specified
```rust
let x: i32 = 5;
```
Bindings by default are immmutable. Mutable binding can be created using ```mut``` keyword
```rust
let mut x: i32 = 5;
```

### Functions
Simple function
```rust
fn main() {
    ...
}
```
Function with arg and return
```rust
fn add_one(x: i32) -> i32 {
    x + 1 //no semicolon here!
}
```
Pass mutable arg
```rust
let mut x: i32 = 5;
inc(&mut x);
```
```rust
fn inc(x: &mut i32) {
    *x = *x + 1;
}
```

### Printing
```rust
println!("text");
println!("x = {}", x);
```

### Structs
Struct declaration
```rust
struct Point {
    x: f64,
    y: f64,
}
```
Struct initialization
```rust
let p = Point { x: 0.0, y: 0.0 };
```
Methods for struct
```rust
impl Point {
    fn new(x: f64, y: f64) -> Point {
        Point { x: x, y: y }
    }
    
    fn origin() -> Point {
        Point { x: 0.0, y: 0.0 }
    }

    fn print(&self) {
        println!("x: {}, y: {}", self.x, self.y);
    }

    fn mv(&mut self, x: f64, y: f64) {
        self.x += x;
        self.y += y;
    }
}
```
```rust
let mut p = Point::origin();
p.mv(5.0, 5.0);
p.print();
```

### Traits
A ```trait``` is a collection of methods defined for an unknown type: ```Self```.
Implementation of ```Display``` trait for Point struct.
```rust
impl std::fmt::Display for Point {
    fn fmt(&self, f: &mut std::fmt::Formatter) -> std::fmt::Result {
        write!(f, "({}, {})", self.x, self.y)
    }
}
```
```rust
let p = Point { x: 0.0, y: 0.0 };
print!("{}", p);
```

### Comparision
For primitive types comparision works as usual.
Custom struct comparision require to implement ```PartialEq``` trait.
```rust
impl std::cmp::PartialEq for Point{
    fn eq(&self, other: &Point) -> bool {
        let x = self.x - other.x;
        let y = self.y - other.y;
        x.abs() < 0.1 && y.abs() < 0.1
    }
}
```
```rust
println!("are equals: {}", Point { x: 0.0001, y: 0.0001 } == Point::origin());
```

### Pattern matching
Standard pattern matching
```rust
let x = 3;
match x {
    0 ... 5 => println!("x is between 0 and 5"),
    _ => println!("x is not between 0 and 5"),
}
```
Some methods returns Option\<T>. Like find method of string. Result of this function can be handled by pattern matching.
```rust
let result = "Rust is cool".find("cool");
match result {
    Some(r) => println!("Rust is cool and cool is at index {}",  r),
    None => println!("Apparently Rust is not cool")
}
```

### Loops
For in loop
```rust
let vector = vec![1,1,2,3,5,8];
for i in vector {
    println!("i == {}", i);
}
```
```rust
for i in 0..10 {
    println!("i == {}", i);
}
```
While. Rust has standard while loop and also infinite loop. In loops ```break``` and ```continue``` can be used.
```rust
let mut done = false;
while !done {
    ... //set done = true; at some point
}
```
```rust
while {
    ... //break here at some point
}
```

### If/else
```rust
let n = 5;
if n < 0 {
    print!("{} is negative", n);
} else if n > 0 {
    print!("{} is positive", n);
} else {
    print!("{} is zero", n);
}
```

### Result
Function can return ```Result<T, K>``` where ```T``` is result type and ```K``` is error type.
```rust
fn get_error() -> Result<i32, i32> {
    Err(1)
}
```
```rust
fn get_result() -> Result<i32, i32> {
    Ok(1)
}
```
Result<T, K> can be handled on a few ways.

Unwrap will return value if Ok and panic if Err.
```rust 
let r = get_result().unwrap();
```
Expect will return value if Ok and panic with message if Err.
```rust 
let r = get_result().expect("Something went wrong!");
```
Pattern matching can be used also.
```rust
let r = match get_result() {
    Ok(v) => v,
    Err(e) => panic!("get_result returned Err {}", e)
};
```
### Option
Function can return ```Option<T>```. Which works in a same way as ```Result<T, K>``` but not allow to specify type of error. When returning ```Option<T>``` ```Some<T>``` or ```None``` should be returned.

### Read file 
```rust 
let mut data = Vec::new();
let mut f = File::open("path to file").expect("Can't open file!");
f.read_to_end(&mut data).expect("Failed to read file content!");
println!("{}", data.len());
let s = String::from_utf8(data).expect("Failed convert data to string!");
println!("{}", s);
```