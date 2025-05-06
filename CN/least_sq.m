 function [coefs,err]=least_sq(x,f,k)
    V = vander(x);
    n = length(x);
    A = V(:,n-k:end);
    [coefs,err]=linsys2(A,f');
 end