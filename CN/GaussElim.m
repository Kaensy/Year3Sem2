function x=GaussElim(A,b)
  A=[A b];
  n=length(b);
  for k=1:n-1
    [valmax,pozmax]=max(abs(A(.......)));
    pozpivot=......;
    if valmax==0
      disp('NU avem solutie unica!');
      return;
    elseif pozpivot!=k
      A([...,...],....)=A([...,...],....);
    end
    for i=...:...
      A(i,k:end)=A(i,k:end)-A(...,....)*A(...,...)/A(...,...);
    end
  end
  x=backwardsubs(...,...);

