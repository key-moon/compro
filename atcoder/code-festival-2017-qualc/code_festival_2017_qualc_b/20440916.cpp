// detail: https://atcoder.jp/contests/code-festival-2017-qualc/submissions/20440916
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int n;
  cin >> n;
  ll total = 1;
  ll except = 1;
  for (int i = 0; i < n; i++){
    int a;
    cin >> a;
    if (!(a & 1)) except *= 2;
    total *= 3;
  }
  cout << total - except << endl;
}
