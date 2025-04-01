function x=SOR_it(A,b,NrIt,omega)
%omega este omis pentru Jacobi si Gauss-Seidel
  x_old=zeros(size(b));
  x=x_old;
  for k=1:NrIt
    for i=1:length(b)
     x(i)=omega*1/A(i,i)*(b(i)...
         -A(i,1:i-1)*x(1:i-1)...
         -A(i,i+1:end)*x_old(i+1:end))...
         +(1-omega)*x_old(i);
    end
     x_old=x;
  end

