function x=sol_sys_chol(A,b)
 R=Cholesky(A);
 y=forwardsubs(R',b);
 x=backwardsubs(R,y);
end