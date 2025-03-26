function x=sol_sys_lup(A,b)
 [L,U,P]=lup(A);
 y=forwardsubs(...,...);
 x=backwardsubs(...,...);

