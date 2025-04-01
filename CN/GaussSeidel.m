function [x,ni,rho]=GaussSeidel(A,b,nr_max_it,err,p)
 %omega este omis pentru Jacobi si Gauss-Seidel
 M=tril(A);
 N=M-A;
 T=M\N;
 c=M\b;
 rho=max(abs(eig(T))); %raza spectrala
 if norm(T,p)>=1
   error('Abort!')
 end
 factor=norm(T,p)/(1-norm(T,p));
 x_old=zeros(size(b)); ni=1;
 x=x_old;
 while ni<nr_max_it
   x=c+T*x_old;
   if factor*norm(x-x_old,p)<err
     return;
   else
    x_old=x;
    ni=ni+1;
   end
 end

