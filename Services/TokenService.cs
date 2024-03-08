using JwtBearer.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtBearer.Services
{
    public class TokenService
    {

        //carcaça
        public string Generate(User user) 
        {
            //cria uma instancia do JwtSecurityTokenHandler, cria o token 
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey.PadRight(32));

            //criaçao da chave para que o  token seja assinado;
            //"HMAC256"

          var credenciais =  new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature);



            var tokenDescriptor = new SecurityTokenDescriptor
            {

                //subject o assunto do token
                Subject=GenerateClaims(user),
                SigningCredentials = credenciais,
                Expires =DateTime.UtcNow.AddHours(2),
            };


            //gera o token ou seja ele cria um token 
            var token = handler.CreateToken(tokenDescriptor);


            //gera uma string do token ele escreve o token 
            var strtoken = handler.WriteToken(token);

            return strtoken;


        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim(ClaimTypes.Name, user.email));

            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role));

            ci.AddClaim(new Claim("Fruta", "Banana"));

            return ci;
        }
    }



}
