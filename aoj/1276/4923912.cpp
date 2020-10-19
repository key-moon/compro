// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1276/judge/4923912/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int MAX = 1500000;

vector<bool> isp(MAX);
int main(){
  for (int i = 2; i < MAX; i++){
    for (int j = i * 2; j < MAX; j += i){
      isp[j] = true;
    }
  }
  while (1){
    int n;
    cin >> n;
    if (n == 0) break;
    int mx = n;
    while (isp[mx]) mx++;
    int mn = n;
    while (isp[mn]) mn--;
    cout << mx - mn << endl;
  }
}

