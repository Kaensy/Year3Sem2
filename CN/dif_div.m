function T=dif_div(x,f)
T=NaN(length(x));
T(:,1)=f;
 for j=2:length(x)
     T(1:end-j+1,j)=diff(T(1:end-j+2,j-1))./(x(j:end)-x(1:end-j+1))';
 end
