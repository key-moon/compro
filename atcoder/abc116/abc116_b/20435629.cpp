// detail: https://atcoder.jp/contests/abc116/submissions/20435629
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a;
  cin >> a;
  unordered_set<int> s;
  for (int i = 1; ; i++) {
    if (s.count(a)) {
      cout << i << endl;
      return 0;
    }
    s.insert(a);
    if (a & 1) a = a * 3 + 1;
    else a /= 2;
  }
}
