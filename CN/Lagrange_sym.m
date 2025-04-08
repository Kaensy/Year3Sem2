function L=Lagrange_sym(x,f)
syms X;
L = sym(0);
n=length(x);
j=1:n;
for k=1:n
    L=L+prod(X-x(j~=k))/prod(x(k)-x(j~=k))*f(k);
end
L=expand(L);