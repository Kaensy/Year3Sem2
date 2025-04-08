function L=LagrangeBary(x,f,X,type)
  %noduri: x=[x1,...,xn]
  %valori in noduri: f=[f(x1),...,f(xn)]
  %L=valoarea pol. Lagrange in vectorul X
  %type='none','echidistante','Cebisev1','Cebisev2'
  w=CoeffBary(x,type);

  L=zeros(size(X));
  for k=1:length(X)
    x_pos=find(X(k)==x);
    if isempty(x_pos)
       L(k)=sum(w./(X(k)-x).*f)/sum(w./(X(k)-x));
    else
       L(k)=f(x_pos);
    end
  end
