#include<iostream>
#include<cstdio>

#define MIN(a,b)				((a)<(b)?(a):(b))

using namespace std;

int main()
{
    FILE *fin,*fout;
    fin=fopen("B-large.in","r");
    fout=fopen("output.txt","w");
    int i,j,xx,t;
    double c,f,x,y,y_reach,ans;
    fscanf(fin,"%d",&t);
    for(xx=1;xx<=t;xx++)
    {
        fscanf(fin,"%lf%lf%lf",&c,&f,&x);
        ans=0;
        y=2;
        if(x<=c)
        {
            ans=(x/y);
        }
        else
        {
            y_reach=f*((x/c)-1);
            y=2;

            while(y<y_reach)
            {
                ans+=(c/y);
                y+=f;
            }
            ans+=(x/y);
        }
        fprintf(fout,"Case #%d: %0.7lf\n",xx,ans);
    }
    return(0);
}
