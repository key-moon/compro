// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1180/judge/4923881/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int nxt(int a, int l){
  vector<int> v{};
  for (int i = 0; i < l; i++){
    v.push_back(a % 10);
    a /= 10;
  }
  int dig = 1;
  int mx = 0, mn = 0;
  sort(v.begin(), v.end());
  for (int i = 0; i < l; i++){
    mx = mx * 10 + v[i];
    mn = mn + v[i] * dig;
    dig *= 10;
  }
  return mn - mx;
}

int main(){
  int a, l;
  cin >> a >> l;
  if (l == 0) return 0;
  map<int, int> m{};
  for (int i = 0; ; i++){
    if (m.count(a)){
      cout << m[a] << " " << a << " " << i - m[a] << endl;
      break;
    }
    m[a] = i;
    a = nxt(a, l);
  }
  main();
}

