function d=errel(x,xp,p)
%norm(b-bp, p)	 calculeaza distanta dintre vectorul original B si cel perturbat bp
%norm(b,p)	 calculeaza "marimea" vectorului original
d=norm(x-xp,p)/norm(x,p);
end