// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_10_B/judge/5013764/C++17
#include<bits/stdc++.h>
using namespace std;
const int INF = 1e9+7;

int dp[101][101];
int rs[102],cs[102];

int calc(int l, int r){
  int &ret=dp[l][r];
  if(ret!=-1)return ret;
  ret=INF;
  if(r==l+1) return ret = 0;
  for(int m=l+1;m<=r;m++){
    ret=min(ret,calc(l,m)+calc(m,r)+rs[l]*rs[m]*rs[r]);
  }
  return ret;
  
}

int main(){
  int n;
  cin >> n;
  for(int i=0; i<101; i++){
    for(int j=0; j<101; j++){
      dp[i][j]=-1;
    }
  }
  for(int i=0; i<n; i++){
    cin >> rs[i] >> cs[i];
  }
  rs[n]=cs[n-1];
  cout << calc(0,n) << endl;
  
  
}


