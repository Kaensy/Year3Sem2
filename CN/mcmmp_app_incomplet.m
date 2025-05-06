k=1
clf; axis equal;axis([0 2 0 1]); 
xticks(0:0.2:2);yticks(0:0.2:1); 
grid on;hold on; set(gca,"fontsize", 15)

[x,y]=ginput(1)
X=[x]; Y=[y];
while ~isempty([x,y])
    plot(x,y,'*k','MarkerSize',10);
    [x,y]=ginput(1)  
    X=[X x]; Y= [Y y];
end

[coefs,err]=least_sq(X,Y,k)

least_sq_pol=@(t) polyval(coefs,t);
fplot(least_sq_pol,[0,2])