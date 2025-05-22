function area=repsimpson(f,a,b,n)
  h=(b-a)/n;
  x=a+h:h:b-h;
  x_mid=a*h/2:h:b-h/2
  area= h/6 * (sum(f(x)) * 2 + f(a) + f(b) + sum(f(x_mid))*4);
