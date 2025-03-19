function y=mycos(x)
    x=reducereper(x); 
    semn=1;
    if x>3*pi/2
        x=2*pi-x;          % Lipsește: oglindire față de x=2π
    elseif x>pi
        x=x-pi; semn=-1;   % Lipsește: reducere cu π și schimbare semn
    elseif x>pi/2
        x=pi-x; semn=-1;   % Lipsește: oglindire față de x=π/2 și schimbare semn
    end
    if x<=pi/4
        y=cosred(x);    % Apelează cosred pentru argumentul redus
    else
        y=sinred(pi/2-x); % Folosește identitatea cos(x) = sin(π/2-x)
    end
    y=semn*y;