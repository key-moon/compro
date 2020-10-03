// detail: https://atcoder.jp/contests/arc104/submissions/17177973
#include <bits/stdc++.h>

#define var auto
#define ll long long


using namespace std;

int n;
int k;
int mod;

const int N_MAX = 100;
const int M_MAX = 100;

const int DAT_LEN = 100 * 100 * 100;
const int TMP_LEN = 10;
int tmp[TMP_LEN][DAT_LEN];

void multiple(int arr[DAT_LEN], int width, int k, int res[DAT_LEN]) {
    for (int i = 0; i < DAT_LEN; i++)
        tmp[0][i] = arr[i];

    for (int i = 1; i < TMP_LEN; i++)
    {
        for (int j = 0; j < DAT_LEN; j++)
            tmp[i][j] = tmp[i - 1][j];
        var shift = (1 << (i - 1)) * width;
        for (int j = shift; j < DAT_LEN; j++) {
            tmp[i][j] += tmp[i - 1][j - shift];
            if (mod < tmp[i][j]) tmp[i][j] -= mod;
        }
    }

    for (size_t i = 0; i < DAT_LEN; i++)
        res[i] = arr[i];
    
    int offset = width;
    for (int i = 0; i < TMP_LEN; i++)
    {
        if ((k >> i) & 1) {
            for (int j = offset; j < DAT_LEN; j++)
            {
                res[j] += tmp[i][j - offset];
                if (mod < res[j]) res[j] -= mod;
            }
            offset += (1 << i) * width;
        }
    }
}

int hoge[101][DAT_LEN];

int main() {
    cin >> n >> k >> mod;
    hoge[0][0] = 1;
    multiple(hoge[0], 3, k, hoge[1]);
    for (size_t i = 1; i <= n; i++) {
        multiple(hoge[i - 1], i, k, hoge[i]);
    }
    for (int x = 1; x <= n; x++)
    {
        ll res = 0;
        var target1 = hoge[x - 1];
        var target2 = hoge[n - x];
        for (size_t i = 0; i < DAT_LEN; i++)
        {
            res += ((ll)target1[i]) * target2[i];
            res %= mod;
        }
        res *= (k + 1);
        res -= 1;
        res %= mod;
        cout << res << endl;
    }
}
