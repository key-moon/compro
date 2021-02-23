// detail: https://atcoder.jp/contests/agc017/submissions/20446110
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, p;
  cin >> n >> p;
  ll odd = 0;
  ll even = 1;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (a & 1) {
      ll sum = odd + even;
      odd = sum;
      even = sum;
    }
    else {
      odd *= 2;
      even *= 2;
    }
  }
  cout << (p == 0 ? even : odd) << endl;
}
