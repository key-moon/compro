// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1131/judge/4922133/C++17
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

struct Sum{
  int cnt;
  int maxden;
  int num;
  int den;
  Sum(int cnt, int maxden, int num, int den)
  :cnt(cnt), maxden(maxden), num(num), den(den){}
};

int main(){
  int p, q, a, n;
  cin >> p >> q >> a >> n;
  if (p == 0) return 0;
  stack<Sum> st{};
  st.push(Sum(0, 1, 0, 1));
  int res = 0;
  while (!st.empty()){
    var elem = st.top(); st.pop();
    var num1 = elem.num * q, num2 = p * elem.den;
    if (num1 == num2) res++;
    if (num1 > num2) continue;
    if (elem.cnt == n) continue;
    for (int i = elem.maxden; i * elem.den <= a; i++){
      var newnum = elem.num * i + elem.den;
      var newden = elem.den * i;
      st.push(Sum(elem.cnt + 1, i, newnum, newden));
    }
  }
  cout << res << endl;
  main();
}

