function area=reptrapezium(f,a,b,n)
  h=(b-a)/n;
  x=a:h:b;
  area=h/2*(2*sum(f(x))-f(a)-f(b));

