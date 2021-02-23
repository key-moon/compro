// detail: https://atcoder.jp/contests/abc123/submissions/20436574
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int maxWait = 0;
  int res = 0;
  for (int i = 0; i < 5; i++) {
    int a;
    cin >> a;
    var time = (a + 9) / 10 * 10;
    res += time;
    chmax(maxWait, time - a);
  }
  cout << res - maxWait << endl;
}
