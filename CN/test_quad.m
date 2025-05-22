f=@(x) 4./(x.^2+1)

clf; axis equal;
fplot(f,[0,1],'linewidth',1.5)
axis([0, 1, 0, 4])

format long
quad(f,0,1)

pkg load symbolic
syms x;
int(4/(x^2+1),0,1)

adquad2(f,0,1)
pi

T=romberg(f,0,1,4)
T(4,4)

