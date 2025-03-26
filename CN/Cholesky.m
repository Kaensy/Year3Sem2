function R=Cholesky(A)
n=length(A);   % Obține dimensiunea matricei
R=A;           % Inițializează R cu matricea A (vom suprascrie elementele)

for k=1:n      % Pentru fiecare linie/coloană
   
   % Actualizăm toate rândurile de sub rândul curent
   for j=k+1:n
    % Formula 2 din explicația mea - actualizăm elementele sub formă de produs scalar
    R(j,j:n)=R(j,j:n)-R(k,j:n)*R(k,j)'/R(k,k);
   end
   
   % Formula 1 din explicația mea - actualizăm diagonala și elementele de deasupra
   R(k,k:n)=R(k,k:n)/sqrt(R(k,k));
end

% Extragem doar partea superioară, restul devine zero
R=triu(R);