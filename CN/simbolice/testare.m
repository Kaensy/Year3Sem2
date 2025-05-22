type='None'
w=x^2
pin=orto_poly_sym(w,x,-1,2,2)
nodes=simplify(solve(pin==0))'
coefs=gauss_coefs_sym(w,-1,2,nodes)
f=3*x^3+x^2-x+3
I=simplify(int(f*w,-1,2))
G=simplify(subs(f,nodes)*coefs')

##type='Cebisev1'
##w=1/sqrt(1-x^2)
##pin=orto_poly_sym_type(type,3,[],[])
##nodes=simplify(solve(pin==0))'
##coefs=gauss_coefs_sym(w,-1,1,nodes)
##f=x^5-2*x^4+3*x^3+x^2-x+3
##I=simplify(int(f*w,-1,1))
##G=simplify(subs(f,nodes)*coefs')

##type='Cebisev2'
##w=sqrt(1-x^2)
##pin=orto_poly_sym_type(type,3,[],[])
##nodes=simplify(solve(pin==0))'
##coefs=gauss_coefs_sym(w,-1,1,nodes)
##f=x^5-2*x^4+3*x^3+x^2-x+3
##I=simplify(int(f*w,-1,1))
##G=simplify(subs(f,nodes)*coefs')

##type='Jacobi'
##aa=sym(1)/2
##bb=sym(1)
##w=(1-x)^aa*(1+x)^bb
##pin=orto_poly_sym_type(type,2,aa,bb)
##nodes=simplify(solve(pin==0))'
##coefs=gauss_coefs_sym(w,-1,1,nodes)
##f=3*x^3+x^2-x+3
##I=simplify(int(f*w,-1,1))
##G=simplify(subs(f,nodes)*coefs')

##type='Laguerre'
##aa=sym(2)
##w=x^aa*exp(-x)
##pin=orto_poly_sym_type(type,2,aa,[])
##nodes=simplify(solve(pin==0))'
##coefs=gauss_coefs_sym(w,sym(0),sym(Inf),nodes)
##f=x^2
##I=simplify(int(f*w,0,Inf))
##G=simplify(subs(f,nodes)*coefs')
