function y=mysin(x,digits=1000)
    x=reducereper(x,digits); 
    semn=1;
    if x>3*pi/2
        x=2*pi-x; semn=-1;  % oglindire față de x=2π și schimbare semn
    elseif x>pi
        x=x-pi; semn=-1;    % reducere cu π și schimbare semn
    elseif x>pi/2
        x=pi-x;             % oglindire față de x=π/2
    end
    if x<=pi/4
        y=sinred(x);    % Apelează sinred pentru argumentul redus
    else
        y=cosred(pi/2-x); % Folosește identitatea sin(x) = cos(π/2-x)
    end
    y=semn*y;