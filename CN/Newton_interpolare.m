function L=Newton_interpolare(x,f,X)
T=dif_div(x,f);
coefs=T(1,:);
L=zeros(size(X));
for i=1:length(X)
    prods=cumprod([1,X(i)-x(1:end-1)]);
    L(i)=coefs*prods';
end

