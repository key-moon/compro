// detail: https://atcoder.jp/contests/agc002/submissions/20436732
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b;
  cin >> a >> b;
  if (a <= 0 && 0 <= b) {
    cout << "Zero" << endl;
    return 0;
  }
  if (0 < a || ((b - a) & 1) == 1) {
    cout << "Positive" << endl;
    return 0;
  }
  cout << "Negative" << endl;
}
